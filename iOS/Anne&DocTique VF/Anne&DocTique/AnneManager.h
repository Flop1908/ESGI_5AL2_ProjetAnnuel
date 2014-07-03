//
//  AnneManager.h
//  Anne&DocTique
//
//  Created by Kapi on 01/03/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <CoreLocation/CoreLocation.h>

#import "AnneManagerDelegate.h"
#import "AnneCommunicatorDelegate.h"

@class AnneCommunicator;

@interface AnneManager : NSObject<AnneCommunicatorDelegate>
@property (strong, nonatomic) AnneCommunicator *communicator;
@property (weak, nonatomic) id<AnneManagerDelegate> delegate;

- (void)fetchCountryAtCoordinate:(CLLocationCoordinate2D)coordinate;
@end