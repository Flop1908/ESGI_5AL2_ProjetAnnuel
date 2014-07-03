//
//  AnneCommunicatorDelegate.h
//  Anne&DocTique
//
//  Created by Kapi on 01/03/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol AnneCommunicatorDelegate
- (void)receivedGroupsJSON:(NSData *)objectNotation;
- (void)fetchingCountryFailedWithError:(NSError *)error;
@end
