//
//  Resources.h
//  A&D
//
//  Created by Kapi on 25/03/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "RedditAPI.h"

@interface Resources : NSObject {

}

+ (UIImage *) barImage;
+ (UIImage *) loadingImage;

+ (UIColor *) cOrange;
+ (UIColor *) cGreen;
+ (UIColor *) cNormal;
+ (UIColor *) cBlue;
+ (UIColor *) cTitleColor;

+ (UIFont *) mainFont;
+ (UIFont *) secondaryFont;
+ (UIFont *) tertiaryFont;

+ (UIImage *) videoIcon;
+ (UIImage *) articleIcon;
+ (UIImage *) imageIcon;

+ (UIImage *) rightArrowDimImage;

+ (void) processPost:(NSMutableDictionary *) post;

@end
