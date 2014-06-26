#import "VDMEntryCell.h"
#import "VDMEntryCellBackground.h"
//#import "VDMSettings.h"
//#import "ASIHTTPRequest.h"

@implementation VDMEntryCell
@synthesize textView;

-(void) awakeFromNib {
	//self.backgroundView = [UIColor cyanColor];//[[[VDMEntryCellBackground alloc] init] autorelease];
	//self.selectedBackgroundView = [[[VDMEntryCellBackground alloc] init] autorelease];
}

/*
-(IBAction) vote:(UIButton *) sender {
	if ((sender == youDeservedIt && entry.deserveVoted) || (sender == yourLifeSucks && entry.agreeVoted)) {
		[UIView animateWithDuration:0.4 animations:^{
			sender.alpha = 0;
		} completion:^(BOOL finished) {
			[sender setTitle:@"You have already voted" forState:UIControlStateNormal];
			
			[UIView animateWithDuration:0.4 animations:^{
				sender.alpha = 1;
			} completion:^(BOOL finished) {
				[UIView animateWithDuration:0.4 delay:2 options:0 animations:^{
					sender.alpha = 0;
				} completion:^(BOOL finished) {
					[self setDeserveCount:entry.deserveCount];
					[self setLifeSucksCount:entry.agreeCount];
					
					[UIView animateWithDuration:0.4 animations:^{
						sender.alpha = 1;
					}];
				}];
			}];
		}];
	}
	else {
		[UIView animateWithDuration:0.4 animations:^{
			sender.alpha = 0;
		} completion:^(BOOL finished) {
			if (sender == youDeservedIt) {
				entry.deserveCount++;
				entry.deserveVoted = YES;
				[self setDeserveCount:entry.deserveCount];
				[self registerVote:@"deserved"];
			}
			else {
				entry.agreeCount++;
				entry.agreeVoted = YES;
				[self setLifeSucksCount:entry.agreeCount];
				[self registerVote:@"agree"];
			}
		
			[UIView animateWithDuration:0.4 animations:^{
				sender.alpha = 1;
			}];
		}];
	}
}

-(void) setDeserveCount:(int) count {
	[youDeservedIt setTitle:[NSString stringWithFormat:@"you deserved(%d)", count] forState:UIControlStateNormal];
}

-(void) setLifeSucksCount:(int) count {
	[yourLifeSucks setTitle:[NSString stringWithFormat:@"your life sucks (%d)", count] forState:UIControlStateNormal];
}
*/
-(UILabel*)setDate:(UILabel *)date
{
    _dates=date;
    return _dates;
}
-(UILabel*)setAuthor:(UILabel *)Author
{
    return _authors;
}
-(UITextView *)setTextView:(UITextView *)textView
{
    textView=textView;
    return textView;
}

- (void)dealloc
{
    textView=nil;
    _authors=nil;
    _dates=nil;
	//SafeRelease(youDeservedIt);
	//SafeRelease(yourLifeSucks);
	//SafeRelease(textView);
	//[super dealloc];
}

@end
